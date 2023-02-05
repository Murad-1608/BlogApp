﻿using Entity.Concrete;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetSenderMessage(int id);
        List<Message> GetReceiverMessage(int id);
        void Delete(int id);
        void Add(Message message);

        Message ViewMessage(int id);
    }
}
