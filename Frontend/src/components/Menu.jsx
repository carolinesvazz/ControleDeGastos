import { Link, useNavigate } from "react-router-dom";

// Componente responsável pelo menu de navegação da aplicação.

export default function Menu() {

    const navigate = useNavigate();

    function sair() {
        localStorage.removeItem("token");
        navigate("/");
    }

    return (
        <nav style={menu}>

            <h2>💰 Controle de Gastos</h2>

            <div>

                <Link style={link} to="/dashboard">
                    Dashboard
                </Link>

                <Link style={link} to="/pessoas">
                    Pessoas
                </Link>

                <Link style={link} to="/transacoes">
                    Transações
                </Link>

                <Link style={link} to="/consulta-totais">
                    Consulta de Totais
                </Link>

              <button style={botao} onClick={sair}>
    Sair
                </button>

            </div>

        </nav>
    );
}

// Estilos da barra de navegação.

const menu = {
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    padding: "18px 35px",
    background: "#18181b",
    borderBottom: "1px solid #333"
};

// Estilo dos links do menu.

const link = {
    color: "#fff",
    textDecoration: "none",
    marginRight: "25px",
    fontWeight: "500",
    fontSize: "18px"
};

// Estilo do botão de saída.

const botao = {
    background: "#ef4444",
    color: "white",
    border: "none",
    padding: "8px 16px",
    borderRadius: "8px",
    cursor: "pointer",
    fontWeight: "bold"
};