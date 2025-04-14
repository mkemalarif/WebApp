import { Route, Routes } from "react-router";
import routes from "../../pages/routes";

export default function PrivateLayout() {
    return (
        <Routes>
            {
                routes.map((r) => {
                    const Component = r.component;
                    return (
                        <Route
                            path={`${r.path}/*`}
                            element={<Component />}
                        />
                    )
                })
            }
        </Routes>
    )
}