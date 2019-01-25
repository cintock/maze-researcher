using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;
using System.Threading;

namespace Maze.UI
{
    public class LogTextboxAppender : AppenderSkeleton
    {
        private const int flushTimeoutMs = 100;

        private static volatile TextBox loggingTextbox;

        private SpinLock lockBuffer = new SpinLock();

        private List<string> buffer = new List<string>();

        private System.Threading.Timer flushTimer;

        public LogTextboxAppender()
        {
            flushTimer = new System.Threading.Timer(Flush);
        }

        public static TextBox LoggingTextbox
        {
            set
            {
                loggingTextbox = value;
            }
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            // если просто записывать данные в текстове поле на форме (по одной строчке),
            // то получается очень долго, поэтому если идет непрерывный поток логов, то
            // собираем их и ждем пока наступит затишье, чтобы отдать их выводиться на форму в
            // визуальный компонент
            TextBox textbox = loggingTextbox;
            if (textbox != null)
            {
                string mes = RenderLoggingEvent(loggingEvent) + Environment.NewLine;
                bool lockIsOk = false;
                try
                {
                    lockBuffer.Enter(ref lockIsOk);
                    buffer.Add(mes);
                }
                finally
                {
                    if (lockIsOk)
                    {
                        lockBuffer.Exit();
                    }
                }
                flushTimer.Change(flushTimeoutMs, Timeout.Infinite);
            }
        }

        private void Flush(object state)
        {
            TextBox textbox = loggingTextbox;
            if (textbox != null)
            {
                bool lockIsOk = false;
                string bufferMessages;
                try
                {
                    lockBuffer.Enter(ref lockIsOk);
                    bufferMessages = string.Join("", buffer.ToArray());
                    buffer.Clear();
                }
                finally
                {
                    if (lockIsOk)
                    {
                        lockBuffer.Exit();
                    }
                }
                textbox.Invoke(
                    (Action)(() =>
                    {
                        textbox.AppendText(bufferMessages);
                    }
                ));
            }
        }
    }
}
