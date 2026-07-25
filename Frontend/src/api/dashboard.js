import api from "./api";

// Busca o resumo geral do Dashboard
export const obterResumo = async () => {
    const response = await api.get("/Dashboard");
    return response.data;
};

// Busca o resumo financeiro de cada pessoa
export const obterResumoPorPessoa = async () => {
    const response = await api.get("/Dashboard/por-pessoa");
    return response.data;
};