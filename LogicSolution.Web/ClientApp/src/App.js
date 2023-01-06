import React, { Component, useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import Login from './components/Login/Login';
import Token from './components/Login/Token';
import './custom.css';

function App() {
    const displayName = App.name;
    const { token, setToken } = Token();

    return (
        <>
            {!token ? <Login setToken={setToken} /> :
                <Layout>
                    <Routes>
                        {AppRoutes.map((route, index) => {
                            const { element, ...rest } = route;
                            return <Route key={index} {...rest} element={element} />;
                        })}
                    </Routes>
                </Layout>
            }
        </>
    );
}

export default App;
