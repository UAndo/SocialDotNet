import React, { useState, useEffect, createContext } from 'react';
import { Navigate } from 'react-router-dom';
import httpService from '../services/httpService';

const UserContext = createContext({});

interface User {
    email: string;
}

function AuthorizeView(props: { children: React.ReactNode }) {
    const [authorized, setAuthorized] = useState<boolean>(false);
    const [loading, setLoading] = useState<boolean>(true);
    const [user, setUser] = useState<User>({ email: "" });
    const [redirect, setRedirect] = useState<boolean>(false);

    useEffect(() => {
        let retryCount = 5;
        const maxRetries = 1;
        const delay = 1000;

        const wait = (delay: number) => new Promise(resolve => setTimeout(resolve, delay));

        const axiosWithRetry = async (url: string, options: any) => {
            try {
                const response = await httpService(url, options);
                if (response.status === 200) {

                    const userData = response.data;
                    setUser({ email: userData.email });
                    setAuthorized(true);
                    return response;
                } else if (response.status === 401) {

                    setRedirect(true); 
                    return response;
                } else {
                    throw new Error("" + response.status);
                }
            } catch (error) {
                if (error.response && error.response.status >= 500) {
                    retryCount++;
                    if (retryCount > maxRetries) {
                        setRedirect(true);
                        throw error;
                    } else {
                        await wait(delay);
                        return axiosWithRetry(url, options);
                    }
                } else {
                    setRedirect(true);
                    throw error;
                }
            }
        };

        axiosWithRetry("auth/ping-auth", { method: "GET" })
            .catch(error => {
                console.log(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading...</p>;
    } else {
        if (redirect) {
            return <Navigate to="/login" />;
        }
        if (authorized) {
            return <UserContext.Provider value={user}>{props.children}</UserContext.Provider>;
        } else {
            return <Navigate to="/login" />;
        }
    }
}

export function AuthorizedUser(props: { value: string }) {
    const user: any = React.useContext(UserContext);
    if (props.value === "email") return <>{user.email}</>;
    else return <></>;
}

export default AuthorizeView;
