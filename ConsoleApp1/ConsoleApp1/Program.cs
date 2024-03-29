﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 학생 관리 프로그램
 * 1. 학생관리 - 학생 이름, 국어, 영어, 수학 성적을 저장
 *      - 학생 클래스 정의
 * 2. 학생추가, 학생 목록 출력, 학생 정보 삭제
 *      - Array.Resize(ref 배열변수, 변경할 요소 크기) 사용
 * 3. 프로그램 종료 시 학생 목록들을 파일로 저장
 * 4. 프로그램 시작 시 파일을 불러와 학생 목록을 로드
 */
namespace Student_list_Program
{
    class Student //Student 클래스 정의
    {
        public string name;
        public int kor, eng, math;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 학생 관리 프로그램 메뉴
            // 1. 학생 목록 2. 학생 추가 3.학생 삭제 4. 프로그램 종료
            // 4. 프로그램 종료 메뉴에 들어갈때까지 무한 반복
            int select = 0;

            // 학생 목록 생성
            Student[] std_list = new Student[0]; //빈 std_list 생성

            for (; select != 4;)
            {
                Console.Clear();
                Console.WriteLine("1. 학생 목록 2. 학생 추가 3.학생 삭제 4. 프로그램 종료"); // 다른 번호를 눌러도 프로그램 종료
                Console.Write("메뉴 번호를 입력하세요 : ");
                try
                {
                    select = int.Parse(Console.ReadLine()); //사용자 메뉴 선택
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("메뉴 번호를 정확히 입력해 주세요 !");
                    Console.ResetColor();
                    Console.ReadKey();

                }

                if (select == 1) // 1. 학생 목록
                {
                    StudentListPrint();
                    Console.ReadKey();
                }
                else if (select == 2) // 2. 학생 추가
                {
                    Console.Clear();

                    Array.Resize(ref std_list, std_list.Length + 1);

                    int new_idx = std_list.Length - 1; //std_list 에 새로 추가할 student 인덱스 값

                    std_list[new_idx] = new Student(); //std_list[new_idx]에 새로운 객체 생성
                    Console.WriteLine("학생 정보 추가");
                    Console.Write("학생 이름 : ");
                    std_list[new_idx].name = Console.ReadLine();


                    Console.Write("국어 성적 : ");
                    std_list[new_idx].kor = int.Parse(Console.ReadLine());
                    Console.Write("영어 성적 : ");
                    std_list[new_idx].eng = int.Parse(Console.ReadLine());
                    Console.Write("수학 성적 : ");
                    std_list[new_idx].math = int.Parse(Console.ReadLine());


                    Console.WriteLine("학생 정보 입력에 성공했습니다.");
                    Console.ReadKey();
                }
                else if (select == 3) // 3. 학생 삭제
                {
                    StudentListPrint();

                    if (std_list.Length < 1)
                    {

                        Console.ReadKey();
                    }
                    else
                    {
                        int num;
                        do
                        {
                            Console.Write("삭제할 학생 번호를 입력해주세요 : "); // 번호가 작거나 크면 반복실행
                            num = int.Parse(Console.ReadLine());
                        } while (!(num > 0) || (num > std_list.Length));

                        int del_idx = num - 1; //삭제할 인덱스 값

                        if (del_idx == (std_list.Length - 1))
                        {
                            Array.Resize(ref std_list, std_list.Length - 1); ;
                        }
                        else
                        {
                            std_list[del_idx] = std_list[std_list.Length - 1];
                            Array.Resize(ref std_list, std_list.Length - 1);
                        }

                        Console.WriteLine("{0}번 학생을 성공적으로 삭제했습니다.", num);
                        Console.ReadKey();
                    }
                }
                else //프로그램 종료
                {
                    Console.WriteLine("프로그램을 종료합니다.");

                }
            }

            void StudentListPrint()
            {
                Console.Clear();
                if (std_list.Length <= 0)
                {
                    Console.WriteLine("학생정보가 없습니다.");
                }
                else
                {

                    Console.WriteLine("순번\t\t이름\t\t국어\t\t영어\t\t수학");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    int j = 0;
                    foreach (var student in std_list)
                    {
                        j++;
                        Console.WriteLine("{0 }\t\t{1 }\t\t{2 }\t\t{3 }\t\t{4 }", j, student.name, student.kor, student.eng, student.math);
                    }

                }

            }
        }

    }
}
