import { AntDesignOutlined, CrownOutlined, SmileOutlined, TabletOutlined } from '@ant-design/icons';

export default {
    route: {
        path: '/',
        routes: [
            {
                path: '/welcome',
                name: '欢迎',
                icon: <SmileOutlined />,
                component: './Welcome',
            },
            {
                path: '/admin',
                name: '管理页',
                icon: <CrownOutlined />,
                access: 'canAdmin',
                component: './Admin',
            },
            {
                name: '列表页',
                icon: <TabletOutlined />,
                path: '/list',
                component: './ListTableList',
            }
        ],
    },
    location: {
        pathname: '/',
    },
};
