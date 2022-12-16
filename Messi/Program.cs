namespace Messi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.SetConfig();
            ApplicationConfiguration.Initialize();
            /**
               *��ǰ�û��ǹ���Ա��ʱ��ֱ������Ӧ�ó���
             * ������ǹ���Ա����ʹ��������������������ȷ��ʹ�ù���Ա�������
             */
            //��õ�ǰ��¼��Windows�û���ʾ
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new(identity);
            //�жϵ�ǰ��¼�û��Ƿ�Ϊ����Ա
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //����ǹ���Ա����ֱ������
                Application.Run(new MainForm());
            }
            else
            {
                //������������
                System.Diagnostics.ProcessStartInfo startInfo = new()
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    //������������,ȷ���Թ���Ա�������
                    Verb = "runas"
                };
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                //�˳�
                Application.Exit();
            }
        }
    }
}