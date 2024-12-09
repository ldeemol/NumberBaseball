using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace numberbaseball
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //문자입력받을것
            string UserNumber;

            // 숫자만 적었을경우 받을 값
            int SuUserNumber;

            //컴퓨터 숫자 3개
            int ComputerNumber1;
            int ComputerNumber2;
            int ComputerNumber3;

            //유저가 적은 숫자확인(100의 자리)(10의 자리)(1의 자리) 체크할 변수
            int UserNumberCheck1 = 1;
            int UserNumberCheck10 = 10;
            int UserNumberCheck100 = 100;

            //랜덤한 숫자 넣어주는 것
            Random randonNum = new Random();

            //문자를 넣을때 숫자인지 아닌지 체크 해주는 값 
            bool Strcheck;

            //유저의 목숨
            int UserLife=9;

            //결과값을 알려줄것들
            int Ball=0;
            int Strike=0;
            int Out = 0;

            Console.WriteLine("!숫자 야구!");
            Console.WriteLine();
            //1~9까지의수 랜덤 출력
            ComputerNumber1 = randonNum.Next(1, 10);
            ComputerNumber2 = randonNum.Next(0, 10);
            ComputerNumber3 = randonNum.Next(0, 10);

            //컴퓨터 숫자 중복 체크
            while(ComputerNumber1 == ComputerNumber2 || ComputerNumber1 == ComputerNumber3 || ComputerNumber2 == ComputerNumber3){
                ComputerNumber1 = randonNum.Next(1, 10);
                ComputerNumber2 = randonNum.Next(0, 10);
                ComputerNumber3 = randonNum.Next(0, 10);
            }
            
            //게임 반복조건(못마추거나 패배할경우)
            while(UserLife>=0)
            {
                if (UserLife <= 0)
                {
                    Console.WriteLine("사망");
                    Console.WriteLine();
                    Console.WriteLine($"정답은! {ComputerNumber1}{ComputerNumber2}{ComputerNumber3} 입니다");
                    break;
                }
                else if (UserLife > 0) {
                    Console.WriteLine($"목숨 {UserLife}개 남았습니다");
                    Console.WriteLine();
                }
                //숫자입력
                Console.Write("숫자를 입력해주세요: ");
                UserNumber = Console.ReadLine();
                Console.WriteLine();

                //문자체크
                Strcheck = int.TryParse(UserNumber, out SuUserNumber);

            //숫자가 부족하거나 많진않은지 체크
            UserNumberCheck100 = SuUserNumber / UserNumberCheck100;
            UserNumberCheck10 =  (SuUserNumber -(UserNumberCheck100*100)) / UserNumberCheck10;
            UserNumberCheck1 = (SuUserNumber - ((UserNumberCheck100*100)+(UserNumberCheck10*10))) / UserNumberCheck1;



                //잘못적은경우 루프,
                if (Strcheck == false || UserNumberCheck100 >= 10 || UserNumberCheck10 >= 10 || UserNumberCheck1 >= 10 || UserNumberCheck1 == UserNumberCheck10 || UserNumberCheck1 == UserNumberCheck100 || UserNumberCheck10 == UserNumberCheck100 || UserNumberCheck1 < 0 || UserNumberCheck10 < 0 || UserNumberCheck100 <= 0)
                {
                    //다시체크
                    while (Strcheck == false || UserNumberCheck1 >= 10 || UserNumberCheck10 >= 10 || UserNumberCheck100 >= 10 || UserNumberCheck1 == UserNumberCheck10 || UserNumberCheck1 == UserNumberCheck100 || UserNumberCheck10 == UserNumberCheck100 || UserNumberCheck1 < 0 || UserNumberCheck10 < 0 || UserNumberCheck100 <= 0)
                    {
                        Console.Write("다시 숫자를 입력해주세요: ");
                        UserNumber = Console.ReadLine();
                        Strcheck = int.TryParse(UserNumber, out SuUserNumber);
                        //값 초기화
                        UserNumberCheck1 = 1;
                        UserNumberCheck10 = 10;
                        UserNumberCheck100 = 100;

                        UserNumberCheck100 = SuUserNumber / UserNumberCheck100;
                        UserNumberCheck10 = (SuUserNumber - (UserNumberCheck100 * 100)) / UserNumberCheck10;
                        UserNumberCheck1 = (SuUserNumber - ((UserNumberCheck100 * 100) + (UserNumberCheck10 * 10))) / UserNumberCheck1;
                    }
                }

                    //통과하면 다음 결과물체크
    
                    //100의자리 스트라이크 밑 볼 체크
                    if (UserNumberCheck100 == ComputerNumber1)
                    {
                        Strike++;
                    }
                    else if (UserNumberCheck100 == ComputerNumber2 || UserNumberCheck100 == ComputerNumber3)
                    {
                        Ball++;
                    }

                    //10의자리 스트라이크 밑 볼 체크
                    if (UserNumberCheck10 == ComputerNumber2)
                    {
                        Strike++;
                    }
                    else if (UserNumberCheck10 == ComputerNumber1 || UserNumberCheck10 == ComputerNumber3)
                    {
                        Ball++;
                    }

                    //1의자리 스트라이크 밑 볼 체크
                    if (UserNumberCheck1 == ComputerNumber3)
                    {
                        Strike++;
                    }
                    else if (UserNumberCheck1 == ComputerNumber1 || UserNumberCheck1 == ComputerNumber2)
                    {
                        Ball++;
                    }

                    //아웃 갯수 만들기
                    Out = 3 - (Strike + Ball);

                    //결과값
                    Console.WriteLine($"스트라이크 {Strike}개     볼{Ball}개     아웃{Out}개");

                    //띄어쓰기
                    Console.WriteLine();

                    //전부 마췄을경우
                    if (Strike == 3)
                    {
                        Console.WriteLine("축하합니다 전부 마추셨어요.");
                        //종료
                        break;
                    }
                    //목숨 한개 깍고 모든값
                    else
                    {
                    UserNumberCheck1 = 1;
                    UserNumberCheck10 = 10;
                    UserNumberCheck100 = 100;

                    UserLife = UserLife - 1;

                        Strike = 0;
                        Ball = 0;
                        Out = 0;
                    }

            }




        }
    }
}