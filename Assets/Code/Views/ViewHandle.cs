﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public class ViewHandle<ModelTemplate>: MonoBehaviour, IInteractionObject
    {
        protected ModelTemplate _model;
        private IInteractionStorage _storage;
        public void SetSettings(
            ModelTemplate model, IInteractionStorage storage)
        {
            _model = model;
            _storage = storage;
        }

        public void OnDestroy()
        {
            _storage?.Remove(this);
        }
    }
}
