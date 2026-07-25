import { useEffect, useState } from "react";
import { obterResumo } from "../api/dashboard";
import Menu from "../components/Menu"; 

export default function Dashboard() {

    // Armazena os dados exibidos no painel

    const [resumo, setResumo] = useState({
        totalPessoas: 0,
        totalTransacoes: 0,
        totalReceitas: 0,
        totalDespesas: 0,
        saldo: 0
    });


    useEffect(() => {
        carregarResumo();
    }, []);


    async function carregarResumo() {

        try {

            const dados = await obterResumo();

            setResumo(dados);

        } catch (erro) {

            console.error(erro);

        }
    }


    return (

        <div>

            {/* Menu aparece no topo da página */}
            <Menu />


            {/* Conteúdo do Dashboard */}
                        <div
                style={{
                    maxWidth: "1200px",
                    margin: "0 auto",
                    padding: "30px"
                }}>

                <h1
                    style={{
                        textAlign: "center",
                        marginBottom: "40px",
                        fontSize: "48px"
                    }}
                >
                    Painel Financeiro
                </h1>


                <div
                    style={{
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                        flexWrap: "wrap",
                        gap: "25px"
                    }}
                >


                    <div style={card}>
                        <h3>Total de Pessoas</h3>
                        <h2>{resumo.totalPessoas}</h2>
                    </div>


                    <div style={card}>
                        <h3>Total de Transações</h3>
                        <h2>{resumo.totalTransacoes}</h2>
                    </div>


                    <div style={card}>
                        <h3>Receitas</h3>
                        <h2>R$ {resumo.totalReceitas}</h2>
                    </div>


                    <div style={card}>
                        <h3>Despesas</h3>
                        <h2>R$ {resumo.totalDespesas}</h2>
                    </div>


                    <div style={card}>
                        <h3>Saldo</h3>
                        <h2>R$ {resumo.saldo}</h2>
                    </div>

<div
    style={{
        display: "flex",
        gap: 20,
        flexWrap: "wrap",
        marginTop: 20
    }}
>
    {resumo.pessoas?.map((pessoa) => (
        <div key={pessoa.nome} style={card}>

            <h3>👤 {pessoa.nome}</h3>

            <p>
                <strong>Receitas:</strong><br />
                R$ {pessoa.receitas.toFixed(2)}
            </p>

            <p>
                <strong>Despesas:</strong><br />
                R$ {pessoa.despesas.toFixed(2)}
            </p>

            <p>
                <strong>Saldo:</strong><br />
                R$ {pessoa.saldo.toFixed(2)}
            </p>

        </div>
    ))}
</div>

                </div>

            </div>

        </div>

    );
}



const card = {
    background: "#1b1b1b",
    borderRadius: "12px",
    padding: "25px",

    width: "250px",

    minHeight: "150px",

    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",

    boxShadow: "0 6px 14px rgba(0,0,0,.35)"
};
