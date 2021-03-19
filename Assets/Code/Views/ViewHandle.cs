using Assets.Code.Models;
using System;
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
       
        public void OnDestroy()
        {
            if (_model is InteractiveObjectModel)
                (_model as InteractiveObjectModel).IsActive = false;

            gameObject.SetActive(false);
        }
    }
}
