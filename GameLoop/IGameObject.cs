﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop
{
    public interface IGameObject
    {
        void Update(float deltaTime);
        void Draw();
    }
}
