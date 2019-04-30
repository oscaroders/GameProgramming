using System.Collections;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class particleAttractorLinear : MonoBehaviour, IComponent {

    public Transform Target {
        private get; set;
    }
    public float speed = 5f;

    private IMediator mediator;

	private ParticleSystem ps;
	private ParticleSystem.Particle[] m_Particles;

	private int numParticlesAlive;

	private void Awake () {

        mediator = FindObjectOfType<PlayerController>().Mediator;
        mediator.AddComponent(this);
        ps = GetComponent<ParticleSystem>();

		if (!GetComponent<Transform>()){
			GetComponent<Transform>();
		}
	}

    private void ParticleBurst() {
        StartCoroutine("Burst");
    }

    private IEnumerator Burst() {

        float timeCount = 0;

        while (timeCount < 0.1f) {

            m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
            numParticlesAlive = ps.GetParticles( m_Particles );
            float step = speed * Time.deltaTime;

            for ( int i = 0 ; i < numParticlesAlive ; i++ ) {

                m_Particles[i].position = Vector3.LerpUnclamped( m_Particles[i].position , Target.position , step );
            }

            ps.SetParticles( m_Particles , numParticlesAlive );

            timeCount += Time.deltaTime;
            yield return 0;
        }
        EventManager.TriggerEvent( "DeactivateParticles" );
    }

    public void Send( string message , GameObject thing , float value ) {
        mediator.MessageIndex( message , thing , value , this );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }

    public void OnEnable() {
        EventManager.StartListening("ParticleBurst", ParticleBurst);
    }

    public void OnDisable() {
        EventManager.StopListening( "ParticleBurst" , ParticleBurst );
    }
}
