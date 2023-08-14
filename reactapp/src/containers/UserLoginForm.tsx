import { useState } from "react";

const UserLoginForm = () => {

    const [inputUsername, setInputUsername] = useState("")
    const [inputPassword, setInputPassword] = useState("")


    return (
        <div className="login-form-container">
            <p>Hello, I'm da login form</p>
            <label htmlFor="login-username">Username:</label>
            <input type="text" id="login-username" value={inputUsername} onChange={(event) => event.target.value}/>
            <br/>
            <label htmlFor="login-password">Password</label>
            <input type="text" id="login-password" value={inputPassword} onChange={(event) => event.target.value}/>

        </div>
    )
}

export default UserLoginForm;