// Debug opcional para problemas intermitentes de login.
// Activación: en la consola ANTES de refrescar: window.__AUTH_DEBUG__ = true;
// Luego recargar y observar logs [AuthDebug]. El script NO hace redirect ni retry si __AUTH_DEBUG__ no está activo.
(function(){
  if(!window.__AUTH_DEBUG__) return; // feature flag
  try {
    const path = location.pathname.toLowerCase();
    console.log('[AuthDebug] path', path);
    if(!(path.includes('login-failed') || path.includes('login-callback'))) { console.log('[AuthDebug] fuera de callback/login-failed'); return; }
    let tries = 0; const max=50;
    const start = performance.now();
    const iv = setInterval(()=>{
      tries++;
      const has = Object.keys(localStorage).some(k=>k.startsWith('msal.'));
      if(has){
        console.log('[AuthDebug] tokens visibles intento', tries, 'ms=', Math.round(performance.now()-start));
        clearInterval(iv);
      } else if(tries>=max){
        console.warn('[AuthDebug] sin tokens tras', max*100, 'ms');
        clearInterval(iv);
      }
    },100);
  } catch(e){ console.warn('[AuthDebug] error', e); }
})();
