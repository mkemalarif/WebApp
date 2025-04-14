/* eslint-disable @typescript-eslint/no-explicit-any */
import axios from "axios";
import ls from "../../utility/localStorage";
import { RegisterUser } from "../types/general";

const lsUser: string | undefined = ls.load("WebApplication_token")

const apiAuth = {
    login: (param: any) => axios.create({
        baseURL: `${import.meta.env.VITE_API_HOST}`
    }).post<string>("Auth/Login", param),
    logout: () => axios.create({
        baseURL: `${import.meta.env.VITE_API_HOST}`,
        headers: {
            Authorization: `Bearer ${lsUser}`,
        },
    }).post<string>("Auth/Logout", {}),
    register: (param: RegisterUser) => axios.create({
        baseURL: `${import.meta.env.VITE_API_HOST}`,
        headers: {
            Authorization: `Bearer ${lsUser}`,
        }
    }).post<boolean>("Auth/Register", param)
}

export default apiAuth;
