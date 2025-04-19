// === README.md ===
// Respina XR Client Sample Project for Meta Quest 3
// Unity 2022 LTS | OpenXR 1.0 | Meta Interaction SDK v63
// 
// This sample demonstrates:
//  - Stereoscopic rendering at 90fps
//  - Basic hand tracking interactions
//  - Voice command integration
//  - Local physics for interactable objects
//
// Setup Instructions:
// 1. Install Unity 2022.3 LTS.
// 2. Create a new 3D URP project.
// 3. Open Package Manager and install:
//    - XR Plugin Management
//    - OpenXR Plugin (enable OpenXR and Meta Quest device support)
//    - Meta Interaction SDK v63
// 4. In Project Settings > XR Plug-in Management > OpenXR:
//    - Add features: Hand Tracking, Eye Tracking (optional), Meta Interaction
//    - Select Scripting Backend: IL2CPP, ARM64.
// 5. In Project Settings > Quality, set VSync Count = Dont Sync and Disable VSync.
//    In Player Settings > Other Settings, set Target Frame Rate = 90.
// 6. Copy the Scripts/ folder into Assets/.
// 7. Create a Scene, add XR Origin (from XR Interaction Toolkit). Attach scripts below.
// 8. Press Play in Editor or Build to Quest 3 for testing.
