import {Navigate, Outlet, Route, Routes} from "react-router-dom";
import {DefaultFooter, ProLayout} from "@ant-design/pro-layout";
import route from "./configs/route";

export default () => {

    return (
        <div
            style={{
                height: '100vh',
            }}
        >
            <ProLayout
                headerHeight={0}
                menuItemRender={(item, dom) => <div> {dom}</div>}
                subMenuItemRender={(_, dom) => <div> {dom}</div>}
                title="秀动辅助"
                siderWidth={120}
                menuHeaderRender={(logo, title) => (
                    <div
                        id="customize_menu_header"
                    >
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
                    <Route path="/" element={<Navigate replace to="/home" />}>
                    </Route>
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
                </Routes>
                <Outlet/>
            </ProLayout>

        </div>
    );
};

