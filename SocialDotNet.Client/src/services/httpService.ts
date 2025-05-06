import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';

const httpService = async (url: string, options: AxiosRequestConfig = {}): Promise<AxiosResponse> => {
    const token = localStorage.getItem('jwt');
    try {
        const response = await axios(url, {
            ...options,
            headers: {
                Authorization: `Bearer ${token}`,
                ...(options.headers || {}),
            },
        });

        return response;
    } catch (error) {
        if (error.response && error.response.status === 401) {
            const tokenRefreshed = await refreshAccessToken();
    
            if (tokenRefreshed) {
                return httpService(url, options);
            } else {
                throw new Error('Unauthorized');
            }
        } else {
            throw error;
        }
    }
};

const refreshAccessToken = async (): Promise<boolean> => {
    try {
        const response = await axios.post('auth/refresh-token', {
            refreshToken: localStorage.getItem('refreshToken'),
        });

        if (response.status === 200) {
            const { accessToken } = response.data;
            localStorage.setItem('jwt', accessToken);
            return true;
        } else {
            return false;
        }
    } catch (error) {
        console.error('Error refreshing token:', error);
        return false;
    }
};

export default httpService;
