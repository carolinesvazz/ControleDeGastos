import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Dashboard from "./pages/Dashboard";
import Pessoas from "./pages/Pessoas";
import Transacoes from "./pages/Transacoes";
import ConsultaTotais from "./pages/ConsultaTotais";

function App() {
    return (

         // Define as rotas da aplicação
        <BrowserRouter>
            <Routes>
                {/* Páginas do sistema */}
                <Route path="/" element={<Login />} />
                <Route path="/dashboard" element={<Dashboard />} />
                <Route path="/pessoas" element={<Pessoas />} />
                <Route path="/transacoes" element={<Transacoes />} />
                <Route path="/consulta-totais" element={<ConsultaTotais />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;