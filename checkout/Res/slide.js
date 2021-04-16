function dragandDrop(id, clientX, clientY, distance) {
    const elem = document.querySelector(id);
    let k = 0;
    iME(elem, "mousedown", 0, 0, clientX, clientY);
    const interval = setInterval(function () {
        k++;
        iME(elem, "mousemove", clientX + k, clientY, clientX + k, clientY);

        if (k >= distance) {
            clearInterval(interval);
            iME(elem, "mouseup", clientX + k, clientY, clientX + k, clientY);
        }
    }, 8);

    function iME(obj, event, screenXArg, screenYArg, clientXArg, clientYArg) {
        const mousemove = document.createEvent("MouseEvent");
        mousemove.initMouseEvent(event, true, true, window, 0,
            screenXArg, screenYArg, clientXArg, clientYArg, 0, 0, 0, 0, 0, null);
        obj.dispatchEvent(mousemove);
    }
}

function start(slide, distance) {
    const obj = document.querySelector(slide);
    obj.target = '_self';
    const _owh = obj.getBoundingClientRect();
    let _ox = _owh.width / 2, _oh = _owh.height / 2;
    _ox = Math.floor(Math.random() * _ox + 60);
    _oh = Math.floor(Math.random() * _oh + 60);
    _ox = _ox + _owh.x;
    _oh = _oh + _owh.y;
    dragandDrop(slide, _ox, _oh, distance);
}

async function toDataURL( url) {
    const resp = await fetch(url);
    const blob = await resp.blob();
    return new Promise((resolve, reject) => {
        const reader = new FileReader()
        reader.onloadend = () => resolve(reader.result)
        reader.onerror = reject
        reader.readAsDataURL(blob)
    })
}

async function autoSlide(slide, block, bg) {
    const bgElem = document.querySelector(bg)
    // console.log(bgElem.clientWidth, bgElem.clientHeight)
    const blockElem = document.querySelector(block)
    // console.log(blockElem.clientWidth, blockElem.clientHeight)

    const blockBase64 = await toDataURL(blockElem.src)
    // console.log('block: ', blockBase64)

    const bgBase64 = await toDataURL(bgElem.src)
    // console.log('slide: ', bgBase64)

    let resp = await fetch('https://marun.run/getdistance', {
        body: JSON.stringify({
            'bg_base64': bgBase64,
            'bg_width': bgElem.clientWidth,
            'bg_height': bgElem.clientHeight,
            'block_base64': blockBase64,
            'block_width': blockElem.clientWidth,
            'block_height': blockElem.clientHeight,
        }), // must match 'Content-Type' header
        headers: {
            'content-type': 'application/json'
        },
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors' // no-cors, cors, *same-origin
    })
    const data = await resp.json() // parses response to JSON
    console.log(data)

    start(slide, data.distance-blockElem.offsetLeft)
}

autoSlide("#tcaptcha_drag_button", "#slideBlock", "#slideBg");
