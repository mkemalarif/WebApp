import { Button, Form, Input } from "antd";
import axios from "axios";
import key from "../../common/constant/key";
import ls from "../../utility/localStorage";
import { LoginModel } from "../../common/types/general";
import { toast } from "react-toastify";
import apiAuth from "../../common/api/apiAuth";

export default function Login() {
    const lsUser = ls.load(key.lsUser);

    const [form] = Form.useForm();

    const handleFinish = () => {
        const model: LoginModel = {
            email: form.getFieldValue('email'),
            password: form.getFieldValue('password'),
        }

        apiAuth.login(model).then((res) => {
            axios.create({
                baseURL: `${import.meta.env.VITE_API_HOST}`,
                headers: {
                    Authorization: `Bearer ${lsUser}`,
                },
            }).defaults.headers.common.Authorization = `Bearer ${res}`;

            ls.set(key.lsUser, res);
            document.location.href = "/Home";
        }).catch((err) => {
            toast.error(err.message);
        })
    }

    return (
        <>
            <div style={{ display: "flex", justifyContent: "Center", alignItems: "Center", height: "100vh" }}>
                <Form
                    form={form}
                    layout="vertical"
                    onFinish={handleFinish}
                >
                    <Form.Item name="email" label="Email">
                        <Input />
                    </Form.Item>
                    <Form.Item name="password" label="Password">
                        <Input.Password
                            placeholder="Password"
                        />
                    </Form.Item>
                    <Button type="primary" htmlType="submit">Submit</Button>
                </Form>
            </div>
        </>
    )
}