import axios from "axios";

// Instância do Axios utilizada para realizar as requisições à API.

const api = axios.create({
    baseURL: "http://localhost:5270/api"
});

// Adiciona automaticamente o token JWT em todas as requisições autenticadas.

api.interceptors.request.use((config) => {

    const token = localStorage.getItem("token");

    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
});

export default api;