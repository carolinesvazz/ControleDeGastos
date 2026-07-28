import api from "./api";

// Realiza as operações de cadastro de pessoas na API.

export const listarPessoas = async () => {
    const response = await api.get("/Pessoa");
    return response.data;
};

export const criarPessoa = async (pessoa) => {
    const response = await api.post("/Pessoa", pessoa);
    return response.data;
};

export const atualizarPessoa = async (id, pessoa) => {
    const response = await api.put(`/Pessoa/${id}`, pessoa);
    return response.data;
};

export const excluirPessoa = async (id) => {
    await api.delete(`/Pessoa/${id}`);
};