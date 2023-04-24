using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 아래처럼 구현 안해도 리스트를 이용하면 더 쉽게 구현할 수 있다
    public class Stack<T>
    {
        private const int DefaultCapacity = 4;
        // 기본캐퍼시티의 크기를 4로 한다

        private T[] array;
        // T형식의 배열을 선언
        private int topIndex;
        // 가장 위의 값을 설정

        public Stack()
        {
            array = new T[DefaultCapacity];
            // 배열을 새로운 T형식의 배열을 생성하고 DefaultCapacity의 크기로 설정
            topIndex = -1;
            // topIndex는 -1로 선언
        }

        public int Count { get { return topIndex + 1; } }
        // 가장 처음의 값에 1을 더한 값으로 반환한다 (-1+1=0)

        public void Clear()
        {
            array = new T[DefaultCapacity];
            // 배열을 새로운 T형식의 배열을 생성하고 DefaultCapacity의 크기로 설정
            topIndex = -1;
            // topIndex는 -1로 선언, Clear을 사용할시 맨 처음으로 돌아간다 (-1)
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            // 비어있다면 예외처리함

            return array[topIndex];
            // 배열의 topIndex로 반환
        }

        public bool TryPeek(out T result)
        {
            if (IsEmpty())
            // 비어있다면
            {
                result = default(T);
                // result에 T형식의 기본값으로 대입(초기화)
                return false;
            }
            else
            //비어있지 않다면
            {
                result = array[topIndex];
                // result에 배열의 맨 위값으로 대입
                return true;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            // 비어있다면
                throw new InvalidOperationException();
            // 예외처리함

            return array[topIndex--];
            // 배열의 topIndex에 1을 감소시고 반환 (-2 -> -2 1 감소 = 1)
        }

        public bool TryPop(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                // result에 T형식의 기본값으로 대입(초기화)
                return false;
            }
            else
            {
                result = array[topIndex--];
                // 1 감소한 배열을 result에 대입
                return true;
            }
        }

        public void Push(T item)
        {
            if (IsFull())               // IsFull이면 키워주고
            {
                Grow();                 // 추가하고
            }
            array[++topIndex] = item;   // 늘어난다
        }

        private void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];
            Array.Copy(array, 0, newArray, 0, Count);
            array = newArray;
        }

        private bool IsEmpty()
        {
            return Count == 0;
            // 비어있다
        }

        private bool IsFull()
        {
            return Count == array.Length; 
            // 꽉차있음
        }
    }
}