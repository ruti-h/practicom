import { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

const Login = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [msg, setMsg] = useState("");
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const reset = () => {
    setUsername("");
    setPassword("");
  };

  const onSend = async () => {
    setLoading(true);
    try {
      const res = await axios.post("http://localhost:8080/api/user/login", { UserName: username, Password: password });
      setMsg("Login successful");
      navigate("/recipes");
    } catch (error) {
      if (axios.isAxiosError(error) && error.response && error.response.data) {
        console.error("Server error:", error.response.data);
        setMsg(error.response.data);
      } else {
        console.error("Error:", error);
        setMsg("Login failed, please try again.");
      }
    } finally {
      setLoading(false);
    }
    reset();
  };

  return (
    <div>
      <h2>כניסה</h2>
      <input type="text" value={username} onChange={(e) => setUsername((e.target as HTMLInputElement).value)} placeholder="Username" />
      <input type="password" value={password} onChange={(e) => setPassword((e.target as HTMLInputElement).value)} placeholder="Password" />
      <button onClick={onSend} disabled={loading}>{loading ? "Loading..." : "Login"}</button>
      {msg && <p>{msg}</p>}
      {/* <Link to="/signup">אין לך חשבון? הירשם עכשיו</Link> */}
    </div>
  );
};

export default Login;
