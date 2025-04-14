/* eslint-disable @typescript-eslint/no-explicit-any */
import axios from "axios";
import ls from "../../utility/localStorage";
import { LoginModel, RegisterUser } from "../types/general";
import key from "../constant/key";

const lsUser: string | undefined = ls.load(key.lsUser)

const apiAuth = {
    login: (param: LoginModel) => axios.create({
        baseURL: `${import.meta.env.VITE_API_HOST}`
    }).post<string>("Auth/Login", param),
    logout: () => axios.create({
        baseURL: `${import.meta.env.VITE_API_HOST}`,
        headers: {
            Authorization: `Bearer ${lsUser}`,
        },
    }).post<string>("Auth/Logout", {}).then(() => ls.clear()),
    register: (param: RegisterUser) => axios.create({
        baseURL: `${import.meta.env.VITE_API_HOST}`,
        headers: {
            Authorization: `Bearer ${lsUser}`,
        }
    }).post<boolean>("Auth/Register", param)
}

export default apiAuth;
