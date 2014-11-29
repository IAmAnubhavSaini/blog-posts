#include <windows.h>
#include <stdio.h>

struct BinarySearchObject{
	int left, right, toFind;
	int *numbers;
	int rangeStart, rangeEnd;
};
typedef struct BinarySearchObject BSO;

void getBinarySearchRange(BSO *bso);
BSO *getBSO(int left, int right, int Array[], int toFind);
int binarySearch(BSO *bso);
int getCPUCoreCount();

int main(void) {
	int leftIndex, rightIndex;
	int numbers[] = { 1, 1, 3, 4, 4, 4, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 19, 20 };
	BSO *bso = getBSO(0, 19, numbers, 4);
	getBinarySearchRange(bso);
	printf("\nRange : %d - %d\n", bso->rangeStart, bso->rangeEnd);
	printf("\n%02d processors", getCPUCoreCount());
	return 0;
}

int getCPUCoreCount(){
	SYSTEM_INFO sysinfo;
	GetSystemInfo(&sysinfo);
	return sysinfo.dwNumberOfProcessors;
}

BSO *getBSO(int left, int right, int Array[], int toFind) {
	BSO * bso = (BSO*)malloc(sizeof(BSO));
	if (bso == NULL){
		abort();
	}
	bso->left = left;
	bso->right = right;
	bso->numbers = Array;
	bso->toFind = toFind;
	return bso;
}

void getBinarySearchRange(BSO *bso) {
	BSO *leftBSO = NULL;
	BSO *rightBSO = NULL;
	int left = bso->left;
	int right = bso->right;
	int toFind = bso->toFind;
	int *Array = bso->numbers;
	int mostLeft;
	int mostRight;
	int foundIndex = binarySearch(bso);
	mostLeft = -1;
	mostRight = -1;

	if (foundIndex >= 0){
		if (foundIndex - 1 >= 0 && Array[foundIndex - 1] == toFind){
			leftBSO = getBSO(left, foundIndex - 1, Array, toFind);
			mostLeft = binarySearch(leftBSO);
		}
		if (mostLeft == -1){
			mostLeft = foundIndex;
		}
		if (foundIndex + 1 <= right && Array[foundIndex + 1] == toFind){
			rightBSO = getBSO(foundIndex + 1, right, Array, toFind);
			mostRight = binarySearch(rightBSO);
		}
		if (mostRight == -1){
			mostRight = foundIndex;
		}
	}
	bso->rangeStart = mostLeft;
	bso->rangeEnd = mostRight;
}

int binarySearch(BSO *bso) {
	int mid = -1;
	BSO * rightBSO = NULL;
	BSO * leftBSO = NULL;
	while (bso->left <= bso->right){
		mid = bso->left + (bso->right - bso->left) / 2;
		if (bso->numbers[mid] == bso->toFind){
			return mid;
		}
		else if (bso->numbers[mid] > bso->toFind) {
			leftBSO = getBSO(bso->left, mid - 1, bso->numbers, bso->toFind);
			return binarySearch(leftBSO);
		}
		else { // going right
			rightBSO = getBSO(mid + 1, bso->right, bso->numbers, bso->toFind);
			return binarySearch(rightBSO);
		}
	}
	return -1;
}
