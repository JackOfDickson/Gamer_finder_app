import React, { FormEvent, useState } from 'react'
import { registerUser } from '../services/serverService'
import newUserInfo from '../types/newUserInfo'


function NewUserForm() {

    const [inputUsername, setInputUsername] = useState("")
    const [inputEmail, setInputEmail] = useState("")
    const [inputPassword, setInputPassword] = useState("")

    const handleNewUserSubmit = (evt: FormEvent) => {
        evt.preventDefault()
        const newUser: newUserInfo = {
            username: inputUsername,
            email: inputEmail,
            password: inputPassword
        }
        registerUser(newUser)
        setInputEmail("")
        setInputPassword("")
        setInputUsername("")
    }

    return (
    <div>
        <p>I'm a user form</p>
            <form onSubmit={handleNewUserSubmit}>
                <label htmlFor="input-username">Username:</label>
                <input type="text" id="input-username" value={inputUsername} onChange={(event) => setInputUsername(event.target.value)} required />
                <br/>
                <label htmlFor="input-email">Email:</label>
                <input type="text" id="input-email" value={inputEmail} onChange={(event) => setInputEmail(event.target.value)} required />
                <br/>
                <label htmlFor="input-password">Password:</label>
                <input type="text" id="input-password" value={inputPassword} onChange={(event) => setInputPassword(event.target.value)} required />
                <input type="submit" value="register"/>
            </form>


    </div>
    )
}

export default NewUserForm;