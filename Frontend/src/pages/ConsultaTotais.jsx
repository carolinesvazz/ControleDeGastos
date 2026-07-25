import { useEffect, useState } from "react";
import Menu from "../components/Menu";
import { obterResumo, obterResumoPorPessoa } from "../api/dashboard";

export default function ConsultaTotais() {

    const [resumo, setResumo] = useState(null);
    const [pessoas, setPessoas] = useState([]);

    useEffect(() => {
        carregar();
    }, []);

    async function carregar() {
        try {
            const resumoApi = await obterResumo();
            const pessoasApi = await obterResumoPorPessoa();

            setResumo(resumoApi);
            setPessoas(pessoasApi);

        } catch (erro) {
            console.error(erro);
        }
    }

    if (!resumo)
        return (
            <div>
                <Menu />
                <div style={container}>
                    <h2>Carregando...</h2>
                </div>
            </div>
        );

    return (
        <div>

            <Menu />

            <div style={container}>

                <h1 style={titulo}>Consulta de Totais</h1>

                {/* Resumo Geral */}

                <div style={resumoCard}>

                    <h2>Resumo Geral</h2>

                    <p><strong>Total de Pessoas:</strong> {resumo.totalPessoas}</p>

                    <p><strong>Total de Transações:</strong> {resumo.totalTransacoes}</p>

                    <p><strong>Receitas:</strong> R$ {Number(resumo.totalReceitas).toFixed(2)}</p>

                    <p><strong>Despesas:</strong> R$ {Number(resumo.totalDespesas).toFixed(2)}</p>

                    <p><strong>Saldo:</strong> R$ {Number(resumo.saldo).toFixed(2)}</p>

                </div>

                <h2 style={{ marginTop: 40 }}>
                    Resumo por Pessoa
                </h2>

                <table style={tabela}>

                    <thead>

                        <tr>

                            <th style={celula}>Pessoa</th>

                            <th style={celula}>Receitas</th>

                            <th style={celula}>Despesas</th>

                            <th style={celula}>Saldo</th>

                        </tr>

                    </thead>

                    <tbody>

                        {pessoas.map((pessoa, index) => (

                            <tr key={index}>

                                <td style={celula}>
                                    {pessoa.nome}
                                </td>

                                <td style={celula}>
                                    R$ {Number(pessoa.receitas).toFixed(2)}
                                </td>

                                <td style={celula}>
                                    R$ {Number(pessoa.despesas).toFixed(2)}
                                </td>

                                <td style={celula}>
                                    <strong>
                                        R$ {Number(pessoa.saldo).toFixed(2)}
                                    </strong>
                                </td>

                            </tr>

                        ))}

                    </tbody>

                </table>

            </div>

        </div>
    );

}

// Estilo do container principal da página.

const container = {
    maxWidth: "1100px",
    margin: "40px auto",
    padding: "20px"
};

const titulo = {
    marginBottom: "30px"
};

// Estilo do card que exibe o resumo geral.

const resumoCard = {
    border: "1px solid #333",
    borderRadius: "10px",
    padding: "25px",
    marginBottom: "40px",
    backgroundColor: "#1d1d1d",
    color: "white"
};

// Estilo da tabela de resumo por pessoa.

const tabela = {
    width: "100%",
    borderCollapse: "collapse",
    backgroundColor: "#1d1d1d",
    color: "white"
};

// Estilo das células da tabela.

const celula = {
    border: "1px solid #444",
    padding: "14px",
    textAlign: "center"
};