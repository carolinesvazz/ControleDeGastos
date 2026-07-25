import { useEffect, useState } from "react";
import Menu from "../components/Menu";
import {
    listarPessoas,
    criarPessoa,
    atualizarPessoa,
    excluirPessoa
} from "../api/pessoas";

export default function Pessoas() {

    // Estados da página
    const [pessoas, setPessoas] = useState([]);
    const [nome, setNome] = useState("");
    const [idade, setIdade] = useState("");
    const [editandoId, setEditandoId] = useState(null);

    // Carrega as pessoas ao abrir a página
    useEffect(() => {
        carregarPessoas();
    }, []);

    // Busca todas as pessoas cadastradas
    async function carregarPessoas() {
        try {
            const dados = await listarPessoas();
            setPessoas(dados);
        } catch (erro) {
            console.error(erro);
        }
    }

     // Cria uma nova pessoa ou atualiza uma existente

async function salvar(e) {
    e.preventDefault();

    if (editandoId) {

        await atualizarPessoa(editandoId, {
            nome,
            idade: Number(idade)
        });

        setEditandoId(null);

    } else {

        await criarPessoa({
            nome,
            idade: Number(idade)
        });

    }

    // Limpa o formulário

    setNome("");
    setIdade("");

    carregarPessoas();
}

// Remove uma pessoa do sistema

    async function remover(id) {
        if (!window.confirm("Deseja excluir esta pessoa?")) return;

        await excluirPessoa(id);

        carregarPessoas();
    }

    return (
        <div>

        {/* Menu de navegação */}
        <Menu />
        
         {/* Conteúdo da página */}
            <div
                style={{
                maxWidth:"1200px",
                margin:"0 auto",
                padding:"30px"
                }}
            >
            <h1>Pessoas</h1>

            <form onSubmit={salvar}>

                <input
                    type="text"
                    placeholder="Nome"
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                />

                <input
                    type="number"
                    placeholder="Idade"
                    value={idade}
                    onChange={(e) => setIdade(e.target.value)}
                />

                    <button type="submit">
                        {editandoId ? "Atualizar" : "Salvar"}
                    </button>

            </form>

            <hr />

            {pessoas.length === 0 ? (
                <p>Nenhuma pessoa cadastrada.</p>
            ) : (
                pessoas.map((pessoa) => (
                    <div key={pessoa.id} style={{ marginBottom: "10px" }}>
                        <strong>{pessoa.nome}</strong> - {pessoa.idade} anos

                            <button
                                onClick={() => {
                                    setNome(pessoa.nome);
                                    setIdade(pessoa.idade);
                                    setEditandoId(pessoa.id);
                                }}
                            >
                                Editar
                            </button>

                            <button
                                style={{ marginLeft: "10px" }}
                                onClick={() => remover(pessoa.id)}
                            >
                                Excluir
                            </button>
                    </div>
                ))
            )}

        </div>
 </div>

);
}