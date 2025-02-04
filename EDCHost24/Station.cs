﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EDCHOST24
{
    class Station //所有站点
    {
        private int MAX_STATION = 3;
        private static List<Dot> mStationList; //一个包含站点位置信息的list
        public void Reset()
        {
            mStationList.Clear();
        } //num复位
        public Station() //构造函数
        {
            List<Dot> mStationList = new List<Dot>();
        }
        public void Add(Dot _inPos)
        {
            if (mStationList.Count() < MAX_STATION)
            {
                if (Dot.IsPosLegal(_inPos))
                {
                    mStationList.Add(_inPos);
                    Debug.WriteLine("New Station, ({0}, {1})", _inPos.x, _inPos.y);
                }
                else
                {
                    Debug.WriteLine("Failed! Location is illegal");
                }
            }
            else
            {
                Debug.WriteLine("Failed! Up to maximum");
            }
        }

        public static bool isCollided(Dot _CarPos, int r=0)
        {
            foreach (Dot station in mStationList)
            {
                if (Dot.Distance(station, _CarPos) < r)
                {
                    return true;
                }
            }
            return false;
        }

        public Dot Index(int i)
        {
            if (i < mStationList.Count())
            {
                return mStationList[i];
            }
            return new Dot(-1, -1);
        }

    }

}
