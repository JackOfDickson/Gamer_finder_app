import { useState } from "react";
import { decryptData, encryptData } from "../services/cryptoService";

function UserLoginForm() {

    const [inputUsername, setInputUsername] = useState("")
    const [inputPassword, setInputPassword] = useState("")

    const requestLogin = () => {
        const encryptedUsername = encryptData(inputUsername)
        console.log(encryptedUsername)
        const decryptedUsername = decryptData(encryptedUsername)
        console.log(decryptedUsername)
        // const encryptedPassword = encryptData(inputPassword)
        // console.log(encryptedPassword)
        // const decryptedPassword = decryptData(encryptedPassword)
        // console.log(decryptedPassword)
    }


    return (
        <div className="login-form-container">
            <p>Hello, I'm da login form</p>
            <label htmlFor="login-username">Username:</label>
            <input type="text" id="login-username" value={inputUsername} onChange={(event) => setInputUsername(event.target.value)}/>
            <br/>
            <label htmlFor="login-password">Password</label>
            <input type="password" id="login-password" value={inputPassword} onChange={(event) => setInputPassword(event.target.value)}/>
            <button onClick={requestLogin}>Submit</button>
        </div>
    )
}

export default UserLoginForm;