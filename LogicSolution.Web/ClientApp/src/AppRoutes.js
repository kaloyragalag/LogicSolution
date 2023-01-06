import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { JSSolution } from "./components/JSSolution";
import Login from "./components/Login/Login"

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    },
    {
        path: '/jssolution',
        element: <JSSolution />
    },
    {
        path: '/login',
        element: <Login/>
    }
];

export default AppRoutes;
