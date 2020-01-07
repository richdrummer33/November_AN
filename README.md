This is Richard's project!

After every lesson I will push updates to the git repository.

After you have cloned my repository (git's version of downloading a project) as I desribed in the tutorial video, you can at any time update your version of the repository. Typically you would do this after each lesson. To do this:

1) Go to your copy of my repo in windows explorer/finder (e.g. C:/GitProjects/November_XX) 

2) Right-clicking in the project folder and clicking "Git Bash Here".

3) In the Git "Bash" terminal, type "git pull". This will update your local repository (project files on your hard drive) to match my latest committed version (version as per the link above).

4) Open the project in Unity! If you already have the project open in Unity, that's fine. Unity will auto update with the updated files.

To see a list of all commits in the repository (i.e. list all versions of the project from previous lessons), type "git log". If you wish to revert to an older version of the project, first copy the hash code of that commit (e.g. 9111f6e77f9dfb78c55cab2a00f6fb15a17f2a49), then  type "git checkout <hash>" but dont type in the <> symbols or quotation marks.

e.g. "git checkout 9111f6e77f9dfb78c55cab2a00f6fb15a17f2a49"

This will update your project files to match that commit.

If you make changes to the project and want to revert back to my version, then you can enter this command "git reset --hard HEAD"