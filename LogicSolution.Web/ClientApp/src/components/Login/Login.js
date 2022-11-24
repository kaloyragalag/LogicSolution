import React, { useState, useEffect } from 'react';
import './Login.css';

const Login = () => {
    var [username, setUsername] = useState('');
    var [password, setPassword] = useState('');

    const login = async(e) => {
        e.preventDefault();
        let item = { username, password };
        let result = await fetch("/authorization/authenticate", {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Accept": "*",
            },
            body: JSON.stringify(item)
        });
        const data = await result.json();
        localStorage.setItem("userInfo", JSON.stringify(data));
        //history.push("/index");
    }

    return (
        <div class="login-clean">
            <form>
                <h2 class="sr-only">Login</h2>
                <div class="form-group">
                    <input class="form-control" type="username" name="username" placeholder="Username" onChange={e => setUsername(e.target.value)}></input>
                </div>
                <div class="form-group">
                    <input class="form-control" type="password" name="password" placeholder="Password" onChange={e => setPassword(e.target.value)}></input>
                </div>
                <div class="form-group">
                    <button class="btn btn-primary btn-block" type="submit" onClick={login}>Log In</button>
                </div>
            </form>
        </div>
    );
}

export default Login;