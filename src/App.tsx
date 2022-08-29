import {Link, Outlet, Route, Routes} from "react-router-dom";
import {DefaultFooter, PageContainer, ProLayout} from "@ant-design/pro-layout";
import route from "./configs/route";
import Home from "./pages/home";
import {useEffect} from "react";
import {post} from "./util/http";
import {MAKE_TOKEN} from "./network/request";

export default () => {

    useEffect(() => {
        post(MAKE_TOKEN, {}, (res) => {
            console.log(res)
        })
    }, []);

    return (
        <div
            style={{
                height: '100vh',
            }}
        >
            <ProLayout
                menuItemRender={(item, dom) => <div> {dom}</div>}
                subMenuItemRender={(_, dom) => <div> {dom}</div>}
                title="秀动辅助"
                logo="https://gw.alipayobjects.com/mdn/rms_b5fcc5/afts/img/A*1NHAQYduQiQAAAAAAAAAAABkARQnAQ"
                menuHeaderRender={(logo, title) => (
                    <div
                        id="customize_menu_header"
                    >
                        {logo}
                        {title}
                    </div>
                )}
                route={route}
                location={{
                    pathname: '/home',
                }}
                footerRender={() => {
                    return <DefaultFooter
                        links={[
                            {
                                key: "github",
                                title: "Github",
                                href: "https://github.com/marunrun/showstart-checkout",
                                blankTarget: true
                            },
                        ]}
                        // @ts-ignore
                        copyright={<a href='https://github.com/marunrun' target='_blank'>marunrun</a>}
                    />

                }}
            >
                <Routes>
                    <Route path="/" element={<Home/>}>

                        {route.routes!.map((route, index) => {
                                return (
                                    <Route
                                        key={index}
                                        path={route.path!}
                                        element={route.component!}
                                    />
                                );
                            }
                        )}
                    </Route>
                </Routes>
                <Outlet/>
            </ProLayout>

        </div>
    );
};

