using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


public class CallCenter
{
    private int _counter = 0;
    public ConcurrentQueue<IncomingCall> Calls { get; private set; }

    public CallCenter()
    {
        Calls = new ConcurrentQueue<IncomingCall>();
    }

    public void End(IncomingCall call)
    {
        call.EndTime = DateTime.Now;
    }

    public bool AreWaitingCalls()
    {
        return Calls.Count > 0;
    }

    // 👇 Estes dois métodos estavam em Program, coloque aqui
    public int Call(int clientId)
    {
        IncomingCall call = new IncomingCall()
        {
            Id = ++_counter,
            ClientId = clientId,
            CallTime = DateTime.Now
        };
        Calls.Enqueue(call);
        return Calls.Count;
    }

    public IncomingCall Answer(string consultant)
    {
        if (Calls.TryDequeue(out IncomingCall call))
        {
            call.Consultant = consultant;
            call.StartTime = DateTime.Now;
            return call;
        }
        return null;
    }
}
