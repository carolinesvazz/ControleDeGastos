import { useEffect, useState } from "react";
import Menu from "../components/Menu";
import {
    listarTransacoes,
    criarTransacao,
    excluirTransacao
} from "../api/transacoes";

import { listarPessoas } from "../api/pessoas";

export default function Transacoes() {

     // Estados da página
    const [transacoes, setTransacoes] = useState([]);
    const [pessoas, setPessoas] = useState([]);

    const [descricao, setDescricao] = useState("");
    const [valor, setValor] = useState("");
    const [tipo, setTipo] = useState(0);
    const [pessoaId, setPessoaId] = useState("");

     // Carrega pessoas e transações ao abrir a página
    useEffect(() => {
        carregarDados();
    }, []);

    // Busca os dados necessários para a tela
    async function carregarDados() {
        const listaTransacoes = await listarTransacoes();
        const listaPessoas = await listarPessoas();

        setTransacoes(listaTransacoes);
        setPessoas(listaPessoas);
    }

    // Cadastra uma nova transação
    async function salvar(e) {
    e.preventDefault();

    try {
        await criarTransacao({
            descricao,
            valor: Number(valor),
            tipo: Number(tipo),
            pessoaId: Number(pessoaId)
        });

        setDescricao("");
        setValor("");
        setTipo(0);
        setPessoaId("");

        carregarDados();

        alert("Transação cadastrada com sucesso!");
    } catch (erro) {
        alert(erro);
    }
}

    async function remover(id) {

        if (!window.confirm("Excluir transação?"))
            return;

        await excluirTransacao(id);

        carregarDados();
    }

   return (
    <div>

        <Menu />

        <div style={{ padding: 30 }}>

            <h1>Transações</h1>

            <form onSubmit={salvar}>

                <input
                    placeholder="Descrição"
                    value={descricao}
                    onChange={(e)=>setDescricao(e.target.value)}
                />

                <input
                    type="number"
                    placeholder="Valor"
                    value={valor}
                    onChange={(e)=>setValor(e.target.value)}
                />

                <select
                    value={tipo}
                    onChange={(e)=>setTipo(e.target.value)}
                >
                    <option value={0}>Receita</option>
                    <option value={1}>Despesa</option>
                </select>

                <select
                    value={pessoaId}
                    onChange={(e)=>setPessoaId(e.target.value)}
                >
                    <option value="">Selecione</option>

                    {pessoas.map(p=>(
                        <option
                            key={p.id}
                            value={p.id}
                        >
                            {p.nome}
                        </option>
                    ))}

                </select>

                <button>Cadastrar</button>

            </form>

            <hr/>

            {transacoes.map(t=>(
                <div
                    key={t.id}
                    style={{marginBottom:12}}
                >

                    <strong>{t.descricao}</strong>

                    {" - R$ "}

                    {t.valor}

                    {" - "}

                    {t.tipo === 0 ? "Receita" : "Despesa"}

                    {" - "}

                    {t.pessoa?.nome}

                    <button
                        style={{marginLeft:10}}
                        onClick={()=>remover(t.id)}
                    >
                        Excluir
                    </button>

                </div>
            ))}

        </div>
                </div>
);
}