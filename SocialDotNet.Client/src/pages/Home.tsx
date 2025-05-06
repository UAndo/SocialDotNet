import { AuthProvider } from "../features/auth/AuthProvider";
import ProtectedRoute from "../features/auth/ProtectedRoute.tsx";
import ChatListView from "../features/chat/ChatListView.tsx";

function Home()
{
    return (
        <AuthProvider>
            <ProtectedRoute>
                <ChatListView currentUserId={""} />
            </ProtectedRoute>
        </AuthProvider>
    );
}

export default Home;