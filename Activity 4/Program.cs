using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_4
{
    class Node
    {
        public int noMhs;
        public string nama;
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        //Method untuk menambahkan sebuah mode ke dalam list

        public void addNote()
        {
            int nim;
            string nm;
            Console.WriteLine("\nMasukan Nomor Mahasiswa: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukan Nama Mahasiswa");
            nm = Console.ReadLine();
            Node nodeBaru = new Node();
            nodeBaru.noMhs = nim;
            nodeBaru.nama = nm;

            //Node ditambahkan sebagai node pertama
            if (START == null || nim <= START.noMhs)
            {
                if((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nNomor Mahasiswa sama tidak di izinkan");
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;

            }
            //Menemukan lokasi node baru didalam list
            Node previous, current;
            previous = START;
            current = START;

            while((current != null) && (nim >= current.noMhs))
            {
                if(nim == current.noMhs)
                {
                    Console.WriteLine("\nNomor Mahasiswa sama tidak diizinkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            //Node Baru akan ditampilkan di antara previous dan current
            nodeBaru.next = current;
            previous.next = nodeBaru;

        }
        //Method untuk menghapus node tertentu didalam list
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //check apakah node yang dimaksud ada didalam list atau tidak
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if(current == START)
            
                START = START.next;
                return true;
            
        }
        //Method untuk meng-check apakah node yang dimaksud ada di dalam list atau tidak
        public bool Search (int nim, ref Node previous, ref Node current)
        {
            previous = current;
            while((current != null)&&(nim != current.noMhs))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        //Method untuk treverse mengunjungi dan membaca isi list
        public void treverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong: ");
            else

            {
                    Console.WriteLine("\nData di dalam list adalah: ");
                    Node currentNode;
                    for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                        Console.Write(currentNode.noMhs + " " + currentNode.nama + "\n");
                    Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START ==null)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while(true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambah data ke dalam list ");
                    Console.WriteLine("2. Menghapus data dari dalam list");
                    Console.WriteLine("3. Melihat semua data didalam list");
                    Console.WriteLine("4. Mencari sebuah data didalam list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nMasukkan Pilihan Anda (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch(ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if(obj.listEmpty())
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan nomor mahasiswa yang akan dihapus: ");
                                int nim = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(nim) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                    Console.WriteLine("Data dengan nomor mahasiswa " + nim + " dihapus ");

                            }
                            break ;
                        case '3':
                            {
                                obj.treverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong !");
                                    break ;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan nomor mahasiswa yang akan di cari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\nData ketemu");
                                    Console.WriteLine("\nNomor mahasiswa: " + current.noMhs);
                                    Console.WriteLine("\nNama: " + current.nama);
                                }
                            }
                            break;
                        case '5':
                            return;
                            default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck nilai yang anda masukkan");
                }

            }
        }
    }
}
