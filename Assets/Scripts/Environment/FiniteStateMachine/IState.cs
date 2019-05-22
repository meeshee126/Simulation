﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    bool Condition();

    void Execute();
}
