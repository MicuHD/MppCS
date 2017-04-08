
using model;
using System.Collections.Generic;


namespace persistance
{
    public abstract class AbstractIMRepository<E, ID> : IRepository<E, ID> where E : IHasID<ID>
    {
        protected List<E> elems = new List<E>();
        protected IValidator<E> validator;


        public AbstractIMRepository(IValidator<E> vali)
        {
            validator = vali;
        }

        public virtual void delete(ID id)
        {
            if (object.Equals(findOne(id), default(E)))
            {
                throw new RepositoryException("ID not found!");
            }
            for (int i = elems.Count - 1; i >= 0; i--)
            {
                if (elems[i].Id.Equals(id))
                {
                    elems.RemoveAt(i);
                    break;
                }
            }
        }

        public virtual IEnumerable<E> findAll()
        {
            return elems;
        }

        public virtual E findOne(ID id)
        {
            foreach(var elem in elems)
            {
                if(elem.Id.Equals(id))
                {
                    return elem;
                }
            }
            return default(E);
        }

        public virtual void save(E entity)
        {
            //if(findOne(entity.Id).Equals(default(E)))
            if(!object.Equals(findOne(entity.Id), default(E)))
            {
                throw new RepositoryException("Duplicate ID!");
            }
            try
            {
                if (!object.Equals(validator,null))
                {
                    validator.validate(entity);
                }
                elems.Add(entity);
            }
            catch(ValidatorException err)
            {
                throw err;
            }
            
        }

        public virtual long size()
        {
            return elems.Count;
        }

        public virtual void update(ID id, E entity)
        {
            if (findOne(id).Equals(default(E)))
            {
                throw new RepositoryException("ID not found!");
            }
            if (!object.Equals(validator,null))
            {
                validator.validate(entity);
            }
            delete(id);
            save(entity);
        }
    }
}
