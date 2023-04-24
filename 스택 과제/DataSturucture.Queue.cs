using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Queue<T>
    {
        private const int DefaultCapacity = 4;
        // 기본 캐퍼시티 값을 4로 설정

        private T[] array;
        private int head;
        private int tail;
        

        

        public Queue()
        {
            array = new T[DefaultCapacity + 1];
            // 배열을 새로운 T형식의 배열을 생성하고 DefaultCapacity +1의 크기로 설정
            head = 0;
            // head를 0으로 선언
            tail = 0;
            // tail을 0으로 선언
        }
        public int Count
        {
            get
            {
                if (head <= tail) 
                // head가 tail보다 앞에 있거나 같은 경우
                    return tail = head;
                // tail의 위치에 head를 대입
                else              
                // tail이 앞에있을때
                    return tail - head + array.Length;
                // head에 배열의 마지막값을 더한 뒤 tail을 뺸 값을 반환한다
            }
        }
        public void Enqueue(T item)
        {
            if (ISFull())
                // 가득 찼을 때
            {
                Grow();
                // 배열을 추가함
            }
            array[tail] = item;
            // item의 값을 배열의 tail에 대입
            MoveNext(ref tail);


        }
        private void MoveNext(ref int index)                    
        // 해당 매개 변수가 가리키는 값
        {
            index = (index == array.Length - 1) ? 0 : index + 1;
            // index가 배열의 마지막 값에서 1을 뺀 값과 같지 않으면 0으로 돌아가고 아니면 인덱스에 1을 더해줌
            
        }

        private bool IsEmpty()            
        // 비어있는 경우
        {
            return head == tail;
            // head와 tail을 같은 값으로 반환한다
        }

        private bool ISFull()             
        //꽉차있는경우
        {
            //return head == tail + 1;
            if (head > tail)              
                return head == tail + 1;
            // head가 tail보다 클 때 있을 때 head 에 tail+1의 값으로 반환한다.
            else
                return head == 0 && tail == array.Length -1;
            // tail이 head보다 클 때 head의 값을 0으로 주고 tail을 배열의 끝에서 -1의 값으로 반환한다.
            // 강아지 꼬리가 머리보다 앞에 있을 수 없으니


            // -1 하는 이유는 헤드의 뒤에 있어야하기 때문에? -1을 안하면 head와 같은 자리에 있기 때문에? (아닌듯 다시보기 ㄱ)
            // 배열이 5개(0 1 2 3 4)일때 맨 끝에 있는건 4
            // head가 앞으로 옮기면 tail이 head가 있던 자리로 옴
        }
        public T Dequeue()
        {
            if (IsEmpty())
                // 비어있는 경우
                throw new InvalidOperationException();
                // 예외처리한다

            T result = array[head];
            // 배열의 head로 대입한다
            MoveNext(ref head);
            return result;
            // MoneNext를 호출하고 head를 다음 위치로 이동시키고 result를 반환
        }
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            // 비어있으면 예외처리함
            return array[head];
            // 배열을 배열의 첫번째 값으로 반환한다
        }
        public void Grow()
        // 배열이 가득 차면 크기를 늘려줌
        {
            int newCapacity = array.Length * 2;             
            // 현재 배열을 2배의 값으로 새로운 배열을 만들어줌
            T[] newArray = new T[newCapacity];
            // T의 배열을 선언하고 선언한 배열의 크기를 위에서 설정한 newCapacity의 배열로 생성함
            if (head < tail)                                
            // tail이 head보다 앞에있을 때 (작을 때) 5(head) < 1(tail)
                Array.Copy(array, newArray, Count);         
            // 무슨 값이 있든 상관없이 전부 복사를 해줌(head도 그대로 tail도 그대로 둬도 문제가 없음, 꽉찰떄 복사해주고 그대로 사용)
            else                                            
            // head가 tail보다 앞에 있을 때 (클때) 1(head) < 5(tail)
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                // 배열과 헤드 새로운 배열의 0번째부터 배열의 마지막 값에서 헤드를 뺸값
                // 헤드부터 끝까지 복사
                Array.Copy(array, 0, newArray, array.Length - head, tail);
                // 배열의 0번부터 새로운 배열의 마지막 값에서 헤드값을 빼고 테일까지 복사)
                // 0번부터 테일까지 복사
                head = 0; 
                // head를 0으로
                tail = Count; 
                // tail을 가장뒤로

                // head와 tail이 엇갈려 있는상황(tail이 더 앞에 있는 상황) 
            }
            array = newArray;
            // 배열을 새로운 배열로 대입한다(교체)

            // 배열이 가득차면 2배로 늘려준다음 tail이 head보다 앞에 있는 경우에는 무슨 값이 있든 전부 복사하고 대입한다.
            // head가 tail보다 앞에 있다면 배열의 0부터 마지막 배열에서 head를 빼고 tail까지 복사한다음 대입한다.

        }
    }
}

