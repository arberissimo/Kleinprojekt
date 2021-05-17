using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Kleinprojekt
{
    public partial class Form1 : Form
    { 
            CspParameters cspp = new CspParameters();
            RSACryptoServiceProvider rsa;

            const string EncrFolder = @"c:\AESDocs\Encrypt\";
            const string DecrFolder = @"c:\AESDocs\Decrypt\";
            const string SrcFolder = @"c:\AESDocs\docs\";

            const string PubKeyFile = @"c:\AESDocs\encrypt\rsaPublicKey.txt";

            const string keyName = "key01";

            private void Form1_Load_1(object sender, EventArgs e)
            {
                InitializeComponent();
            }

            private void bttn_verschluessel_Click(object sender, EventArgs e)
            {
                brow_ver.Refresh();
                if (rsa == null)
                    MessageBox.Show("Schlüssel nicht gesetzt!");
                else
                {
                    openFileDialog1.InitialDirectory = SrcFolder;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string fName = openFileDialog1.FileName;
                        if (fName != null)
                        {
                            FileInfo fInfo = new FileInfo(fName);
                            string name = fInfo.FullName;
                            EncryptFile(name);
                        }
                    }
                }

            }

            private void bttn_entschluessel_Click(object sender, EventArgs e)
            {
                brow_ent.Refresh();
                if (rsa == null)
                    MessageBox.Show("Schlüssel nicht gesetzt!");
                else
                {
                    openFileDialog2.InitialDirectory = EncrFolder;
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        string fName = openFileDialog2.FileName;
                        if (fName != null)
                        {
                            FileInfo fi = new FileInfo(fName);
                            string name = fi.Name;
                            DecryptFile(name);
                        }
                    }
                }
            }

            private void bttn_asmkey_Click(object sender, EventArgs e)
            {
                cspp.KeyContainerName = keyName;
                rsa = new RSACryptoServiceProvider(cspp);
                rsa.PersistKeyInCsp = true;
                if (rsa.PublicOnly == true)
                    MessageBox.Show("Key: " + cspp.KeyContainerName + " – Public Only");
                else
                    MessageBox.Show("Key: " + cspp.KeyContainerName + " – Full Key Pair");
            }

            private void bttn_inp_Click(object sender, EventArgs e)
            {
                StreamReader sr = new StreamReader(PubKeyFile);
                cspp.KeyContainerName = keyName;
                rsa = new RSACryptoServiceProvider(cspp);
                string keytxt = sr.ReadToEnd();
                rsa.FromXmlString(keytxt);
                rsa.PersistKeyInCsp = true;
                if (rsa.PublicOnly == true)
                    MessageBox.Show("Key: " + cspp.KeyContainerName + " – Public Only");
                else
                    MessageBox.Show("Key: " + cspp.KeyContainerName + " – Full Key Pair");
                sr.Close();
            }

            private void bttn_pubexp_Click(object sender, EventArgs e)
            {
                Directory.CreateDirectory(EncrFolder);
                StreamWriter sw = new StreamWriter(PubKeyFile, false);
                sw.Write(rsa.ToXmlString(false));
                sw.Close();
            }

            private void bttn_privkey_Click(object sender, EventArgs e)
            {
                cspp.KeyContainerName = keyName;

                rsa = new RSACryptoServiceProvider(cspp);
                rsa.PersistKeyInCsp = true;

                if (rsa.PublicOnly == true)
                    MessageBox.Show("Key: " + cspp.KeyContainerName + " – Public Only");
                else
                    MessageBox.Show("Key: " + cspp.KeyContainerName + " – Full Key Pair");
            }

            private void EncryptFile(string inFile)
            {
                RijndaelManaged rjndl = new RijndaelManaged();
                rjndl.KeySize = 256;
                rjndl.BlockSize = 256;
                rjndl.Mode = CipherMode.CBC;
                ICryptoTransform transform = rjndl.CreateEncryptor();

                byte[] keyEncrypted = rsa.Encrypt(rjndl.Key, false);

                byte[] LenK = new byte[4];
                byte[] LenIV = new byte[4];

                int lKey = keyEncrypted.Length;
                LenK = BitConverter.GetBytes(lKey);
                int lIV = rjndl.IV.Length;
                LenIV = BitConverter.GetBytes(lIV);

                int startFileName = inFile.LastIndexOf("\\") + 1;
                string outFile = EncrFolder + inFile.Substring(startFileName, inFile.LastIndexOf(".") - startFileName) + ".d3";

                using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                {

                    outFs.Write(LenK, 0, 4);
                    outFs.Write(LenIV, 0, 4);
                    outFs.Write(keyEncrypted, 0, lKey);
                    outFs.Write(rjndl.IV, 0, lIV);

                    using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        int count = 0;
                        int offset = 0;

                        int blockSizeBytes = rjndl.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamEncrypted.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            }
                            while (count > 0);
                            inFs.Close();
                        }
                        outStreamEncrypted.FlushFinalBlock();
                        outStreamEncrypted.Close();
                    }
                    outFs.Close();
                }

            }

            private void DecryptFile(string inFile)
            {
                RijndaelManaged rjndl = new RijndaelManaged();
                rjndl.KeySize = 256;
                rjndl.BlockSize = 256;
                rjndl.Mode = CipherMode.CBC;

                byte[] LenK = new byte[4];
                byte[] LenIV = new byte[4];

                string outFile = DecrFolder + inFile.Substring(0, inFile.LastIndexOf(".")) + ".txt";

                using (FileStream inFs = new FileStream(EncrFolder + inFile, FileMode.Open))
                {

                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Read(LenK, 0, 3);
                    inFs.Seek(4, SeekOrigin.Begin);
                    inFs.Read(LenIV, 0, 3);

                    int lenK = BitConverter.ToInt32(LenK, 0);
                    int lenIV = BitConverter.ToInt32(LenIV, 0);

                    int startC = lenK + lenIV + 8;
                    int lenC = (int)inFs.Length - startC;

                    byte[] KeyEncrypted = new byte[lenK];
                    byte[] IV = new byte[lenIV];

                    inFs.Seek(8, SeekOrigin.Begin);
                    inFs.Read(KeyEncrypted, 0, lenK);
                    inFs.Seek(8 + lenK, SeekOrigin.Begin);
                    inFs.Read(IV, 0, lenIV);
                    Directory.CreateDirectory(DecrFolder);

                    byte[] KeyDecrypted = rsa.Decrypt(KeyEncrypted, false);

                    ICryptoTransform transform = rjndl.CreateDecryptor(KeyDecrypted, IV);

                    using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                    {

                        int count = 0;
                        int offset = 0;

                        int blockSizeBytes = rjndl.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];

                        inFs.Seek(startC, SeekOrigin.Begin);
                        using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamDecrypted.Write(data, 0, count);

                            }
                            while (count > 0);

                            outStreamDecrypted.FlushFinalBlock();
                            outStreamDecrypted.Close();
                        }
                        outFs.Close();
                    }
                    inFs.Close();
                }
            }
        }
    }



