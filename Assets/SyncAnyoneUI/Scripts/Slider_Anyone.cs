#region License
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
/* MIT License                                                                                                                                                                                                                                                                                                                                                                                                                                                                  */
/*                                                                                                                                                                                                                                                                                                                                                                                                                                                                              */
/* Copyright (c) 2000 hatuxes                                                                                                                                                                                                                                                                                                                                                                                                                                                   */
/*                                                                                                                                                                                                                                                                                                                                                                                                                                                                              */
/* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:                             */
/*                                                                                                                                                                                                                                                                                                                                                                                                                                                                              */
/* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.                                                                                                                                                                                                                                                                                                                                               */
/*                                                                                                                                                                                                                                                                                                                                                                                                                                                                              */
/* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Slider_Anyone : UdonSharpBehaviour
{
    Slider _slider;
    [SerializeField] Text _text;

    [UdonSynced(UdonSyncMode.Linear)] float _value;

    void Start()
    {
        _slider = this.gameObject.GetComponent<Slider>();
    }

    void LateUpdate()
    {
        _slider.value = _value;
        _text.text = _value.ToString("F2");
    }

    public void SetValue()
    {
        _value = _slider.value;
    }

    public void ChangerOwner()
    {
        if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject)) Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
    }
}