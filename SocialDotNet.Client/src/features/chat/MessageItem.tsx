interface Message {
    id: string;
    sender: User;
    text: string;
    timestamp: Date;
  }

function MessageItem({ content, isSent }: Message) {
    const messageContainerClass = isSent ? 'sent' : 'received';
    const messageColor = isSent ? 'dark:bg-blue-700 text-white' : 'dark:bg-gray-800 text-white';

    return (
        <div className={`flex ${messageContainerClass}`}>
             <div className={`message ${messageColor}`}>
                {content}
            </div>
        </div>
    );
}

export default MessageItem;
