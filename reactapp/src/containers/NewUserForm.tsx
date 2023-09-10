import React, { useState } from 'react'


function NewUserForm() {

    const [inputUsername, setInputUsername] = useState('')
    const [inputEmail, setInputEmail] = useState('')
    const [inputPassword, setInputPassword] = useState('')

    return (
    <div>
        <p>I'm a user form</p>
            <form>
                <label htmlFor='input-username'>Username:</label>
                <input type='text' id='input-username' value={inputUsername} onChange={(event) => setInputUsername(event.target.value)} required />
                <br/>
                <label htmlFor='input-email'>Email:</label>
                <input type='text' id='input-email' value={inputEmail} onChange={(event) => setInputEmail(event.target.value)} required />
                <br/>
                <label htmlFor='input-password'>Password:</label>
                <input type='text' id='input-password' value={inputPassword} onChange={(event) => setInputPassword(event.target.value)} required />
            </form>


    </div>
    )
}

export default NewUserForm;