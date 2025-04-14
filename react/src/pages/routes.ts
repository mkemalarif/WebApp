import { lazy } from "react";

const Home = lazy(() => import("./Home"));

const routes = [
    {
        path: "/home",
        component: Home
    }
]

export default routes;