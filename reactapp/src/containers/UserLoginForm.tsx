import { useState, FormEvent } from "react";
import { decryptData, encryptData } from "../services/cryptoService";
import { loginUser } from "../services/serverService";
import loginInfo from "../types/loginInfo";

function UserLoginForm() {

    const [inputUsername, setInputUsername] = useState("")
    const [inputPassword, setInputPassword] = useState("")

    const handleLogin = async (evt: FormEvent) => {
        evt.preventDefault()
        const loginInfo: loginInfo = {
            username: inputUsername,
            password: inputPassword
        }
        const result = await loginUser(loginInfo)
        console.log(result)
    }


    return (
        <div className="login-form-container">
            <p>Hello, I'm the login form</p>
            <form onSubmit={handleLogin}>
                <label htmlFor="login-username">Username:</label>
                <input type="text" id="login-username" value={inputUsername} onChange={(event) => setInputUsername(event.target.value)}/>
                <br/>
                <label htmlFor="login-password">Password</label>
                <input type="password" id="login-password" value={inputPassword} onChange={(event) => setInputPassword(event.target.value)}/>
                <input type="submit" value="login"/>
            </form>
        </div>
    )
}

export default UserLoginForm;