using UnityEngine;

public class RepetirChao : MonoBehaviour
{
    private GameController _gameController;


    public bool _chaoInstaciado = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Associando o _gameController ao objeto GameController
        _gameController = FindAnyObjectByType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if (_chaoInstaciado == false)
        {
            if (transform.position.x <= 0)
            {
                _chaoInstaciado = true;
                GameObject ObjetoTeporarioChao = Instantiate(_gameController._chaoPrefab);

                ObjetoTeporarioChao.transform.position = new Vector3(transform.position.x +
                    _gameController._chaoTamanho, transform.position.y, 0);

                Debug.Log("O chão foi instanciado!");
            }

        }

        if (transform.position.x < _gameController._chaoDestruido) // -38
        {
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        // Translate => Move obejeto para os lados 
        transform.Translate(Vector2.left * _gameController._chaoVelocidade * Time.deltaTime);
    }
}
