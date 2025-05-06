import { useAuth } from "./AuthProvider";
import { Navigate } from "react-router-dom";

interface ProtectedRouteProps
{
    children: React.ReactNode;
}

export default function ProtectedRoute({ children }: ProtectedRouteProps)
{
    const { isAuthenticated, loading } = useAuth();
    if (loading) return <div>Loading...</div>;
    if (!isAuthenticated) return <Navigate to="/login" />;
    return <>{children}</>;
}
