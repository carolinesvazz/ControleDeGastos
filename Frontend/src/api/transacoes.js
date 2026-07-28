import api from "./api";

// Realiza as operações de cadastro de transações na API.

export const listarTransacoes = async () => {
    const response = await api.get("/Transacao");
    return response.data;
};

export const criarTransacao = async (transacao) => {
    try {
        const response = await api.post("/Transacao", transacao);
        return response.data;
    } catch (error) {
        throw error.response?.data || error;
    }
};

export const excluirTransacao = async (id) => {
    await api.delete(`/Transacao/${id}`);
};