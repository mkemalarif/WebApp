import { Route, Routes } from "react-router";
import Login from "../../pages/Login";

export default function PublicLayout() {
    return (
        <Routes>
            <Route path="/" element={<Login />} />
        </Routes>
    )
}