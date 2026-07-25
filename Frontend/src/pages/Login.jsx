import { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api/api";

export default function Login() {

    const navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    async function fazerLogin() {

        try {

            const resposta = await api.post("/Usuario/login", {
                email,
                senha
            });

            localStorage.setItem("token", resposta.data.token);
            console.log("TOKEN:", resposta.data.token);

            navigate("/dashboard");

        } catch (erro) {
    console.log(erro);
    console.log(erro.response);

    alert(erro.response?.data || erro.message);
}

    }

    return (

        <div style={{padding:40}}>

            <h1>Controle de Gastos</h1>

            <input
                placeholder="Email"
                value={email}
                onChange={(e)=>setEmail(e.target.value)}
            />

            <br/><br/>

            <input
                type="password"
                placeholder="Senha"
                value={senha}
                onChange={(e)=>setSenha(e.target.value)}
            />

            <br/><br/>

            <button onClick={fazerLogin}>
                Entrar
            </button>

        </div>

    );

}